        using System;
        using System.Net;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Documents;
        using System.Windows.Ink;
        using System.Windows.Input;
        using System.Windows.Media;
        using System.Windows.Media.Animation;
        using System.Windows.Shapes;
        namespace **YourNamespace**
        {
            public class ViewModel
            {
                public MyList TheList {get; set;}
                public MyListGrouping ListGrouping {get; set;}
                public ViewModel()
                {
                    TheList = new MyList();
                    ListGrouping = new MyListGrouping();
                    PopulateLists();
                }
                private void PopulateLists()
                {
                    TheList.DisplayName = "Testing display name";
                    MyList lList = new MyList();
                    lList.DisplayName = "List0";
                    MyList lList1 = new MyList();
                    lList1.DisplayName = "List1";
                    MyList lList2 = new MyList();
                    lList2.DisplayName = "List2";
                    ListGrouping.Title = "Testing title";
                    ListGrouping.Group.Add(mList);
                    ListGrouping.Group.Add(lList);
                    ListGrouping.Group.Add(lList1);
                    ListGrouping.Group.Add(lList2);
                }
            }
        }
