    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Actions;
    using DevExpress.Persistent.Base;
    using DevExpress.ExpressApp.Scheduler.Win;
    using DevExpress.Persistent.Base.General;
    using DevExpress.XtraScheduler;
    
    namespace HowToAccessSchedulerControl.Module.Win {
       public partial class SchedulerController : ViewController {
          public SchedulerController() {
             InitializeComponent();
             RegisterActions(components);
          }
    
          private void SchedulerController_Activated(object sender, EventArgs e) {
              if(View.ObjectTypeInfo.Implements<IEvent>())
                View.ControlsCreated += new EventHandler(View_ControlsCreated);
          }
          void View_ControlsCreated(object sender, EventArgs e) {
             // Access the current List View
             ListView view = (ListView)View;
             // Access the View's List Editor as a SchedulerListEditor
             SchedulerListEditor listEditor = (SchedulerListEditor)view.Editor;
             //  Access the List Editor's SchedulerControl  
             SchedulerControl scheduler = listEditor.SchedulerControl;
             // Set the desired time to be visible
             if (scheduler != null)
                scheduler.Views.DayView.VisibleTime =
                   new TimeOfDayInterval(new TimeSpan(6, 0, 0), new TimeSpan(11, 0, 0));
          }
       }
    }
