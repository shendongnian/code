    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Data;
    using System.Windows.Media;
    using System.Windows;
    public string FilterString { get; set; } // Value searching
    public string FilterColumn { get; set; } // column name
    public string FilterColumnText { get; set; } // by this variable will display text
    System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer(); // by this timer will search about an item becouse for going to next item we need to stop sometime
    private int count = 0;
    private int i = 0;
    // will call to this method and adding treeview control to search about item
    public void FindNode(TreeView tree = null)
        {
            tmr.Interval = new TimeSpan(0, 0, 0, 0, 1);
            // will add count of objects  
            count = FindVisualChildren<DependencyObject>(tree).ToList().Count;
            tmr.Tick += (s, e) =>
            {
                if (i < count)
                {
                    if (FindVisualChildren<Grid>(tree).ToList()[i] != null)
                    {
                        Grid node = FindVisualChildren<Grid>(tree).ToList()[i];
                        if (SelectNode(node))
                        {
                            // if we found the item will stoping the timer
                            tmr.Stop();
                        }
                    }
                    i += 1;
                }
                // will add new count to the variable after expand the items
                count = FindVisualChildren<Grid>(tree).ToList().Count;
            };
            tmr.Start();
        }
    // Search for an item
    bool SelectNode(DependencyObject node)
        {
            bool fo = false;
            for (int i = 0; i < (node as Grid).Children.Count; i++)
            {
                object obj = (node as Grid).Children[i];
                if (obj.GetType() == typeof(Border))
                {
                    TreeViewItem item = ((obj as Border).TemplatedParent as TreeViewItem);
                    if (item != null && item is TreeViewItem)
                    {
                        if (item.Items.Count > 0)
                        {
                            item.IsExpanded = true;
                        }
                        var row = item.Header as DataRowView;
                        if (row[FilterColumn].ToString() == FilterString)
                        {
                            item.IsSelected = true;
                            BindParent(item);
                            fo = true;
                            break;
                        }
                        items.Add(item);
                    }
                }
            }
            return fo;
        }
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                        yield return (T)child;
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
