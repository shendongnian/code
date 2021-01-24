    using System.CodeDom;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyUserControlDesigner))]
    [ToolboxItem(typeof(MyUserControlToolBoxItem))]
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        public string MyTextProperty { get; set; } = "Something";
    }
    public class MyUserControlToolBoxItem : ToolboxItem
    {
        protected override IComponent[] CreateComponentsCore(IDesignerHost host)
        {
            IComponent[] componentsCore = base.CreateComponentsCore(host);
            if (componentsCore != null && componentsCore.Length > 0
                && componentsCore[0] is MyUserControl)
                (componentsCore[0] as MyUserControl)
                    .MyTextProperty = "Something else"; ;
            return componentsCore;
        }
    }
    public class MyUserControlDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            var component = Control;
            var eventBindingService = (IEventBindingService)this.GetService(
                typeof(IEventBindingService));
            var componentChangeService = (IComponentChangeService)this.GetService(
                typeof(IComponentChangeService));
            var designerHostService = (IDesignerHost)GetService(typeof(IDesignerHost));
            var rootComponent = designerHostService.RootComponent;
            var uiService = (IUIService)GetService(typeof(IUIService));
            var designerTransaction = (DesignerTransaction)null;
            try
            {
                designerTransaction = designerHostService.CreateTransaction();
                var e = TypeDescriptor.GetEvents(rootComponent)["Load"];
                if (e != null)
                {
                    var methodName = "";
                    var eventProperty = eventBindingService.GetEventProperty(e);
                    if (eventProperty.GetValue(rootComponent) == null)
                    {
                        methodName = eventBindingService
                            .CreateUniqueMethodName(rootComponent, e);
                        eventProperty.SetValue(rootComponent, methodName);
                    }
                    else
                        methodName = (string)eventProperty.GetValue(rootComponent);
                    var code = this.GetService(typeof(CodeTypeDeclaration))
                            as CodeTypeDeclaration;
                    CodeMemberMethod method = null;
                    var member = code.Members.Cast<CodeTypeMember>()
                        .Where(x => x.Name == methodName).FirstOrDefault();
                    if (member != null)
                    {
                        method = (CodeMemberMethod)member;
                        method.Statements.Add(
                            new CodeSnippetStatement($"{Control.Name}" +
                            $".MyTextProperty = \"Even something else!\";"));
                    }
                    componentChangeService.OnComponentChanged(rootComponent,
                        eventProperty, null, null);
                    eventBindingService.ShowCode(rootComponent, e);
                }
                designerTransaction.Commit();
            }
            catch (System.Exception ex)
            {
                if (designerTransaction != null)
                    designerTransaction.Cancel();
                uiService.ShowError(ex);
            }
        }
    }
