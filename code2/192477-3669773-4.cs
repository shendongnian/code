    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Reflection;
    
    namespace ObjectBrowser
    {
      public partial class PropertyTree : UserControl
      {
        public PropertyTree()
        {
          InitializeComponent();
        }
    
        public object ObjectGraph
        {
          get { return (object)GetValue(ObjectGraphProperty); }
          set 
          {
            if (GetValue(ObjectGraphProperty) != value)
            {
              SetValue(ObjectGraphProperty, value);          
              LoadGraph(treeView1.Items, value);
            }
          }
        }
    
        private void LoadGraph(ItemCollection nodeItems, object instance)
        {
          nodeItems.Clear();
          if (instance == null) return;      
          Type instanceType = instance.GetType();      
          foreach (PropertyInfo pi in 
            instanceType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
          {                
            object propertyValue =pi.GetValue(instance, null);
            TreeViewItem item = new TreeViewItem();
            item.Header = BuildItemText(instance, pi, propertyValue);
            if (!IsPrimitive(pi) && propertyValue != null)
            {
              item.Items.Add(string.Empty);
              item.Tag = propertyValue;
            }
            
            nodeItems.Add(item);
          }
        }
    
        private string BuildItemText(object instance, PropertyInfo pi, object value)
        {
          string s = string.Empty;
          if (value == null)
          {
            s = "<null>";
          }
          else if (IsPrimitive(pi))
          {
            s = value.ToString();
          }
          else
          {
            s = pi.PropertyType.Name;
          }
          return pi.Name + " : " + s;
        }
    
        private bool IsPrimitive(PropertyInfo pi)
        {
          return pi.PropertyType.IsPrimitive || typeof(string) == pi.PropertyType;
        }
        
        public static readonly DependencyProperty ObjectGraphProperty =
            DependencyProperty.Register("ObjectGraph", typeof(object), typeof(PropertyTree), new UIPropertyMetadata(0));
    
        private void treeView1_Expanded(object sender, RoutedEventArgs e)
        {
          TreeViewItem item = e.OriginalSource as TreeViewItem;
          if (item.Items.Count == 1 && item.Items[0].ToString() == string.Empty)
          {
            LoadGraph(item.Items, item.Tag);
          }
        }
      }
    }
