            DataView = (CollectionViewSource)(this.Resources["DataView"]);
            AddGrouping();            
            tabcontrol.DataContext = DataView;            
        }
       
        private void AddGrouping()
        {
            PropertyGroupDescription grouping = new PropertyGroupDescription();
            grouping.PropertyName = "categoryID";
            DataView.GroupDescriptions.Add(grouping);
        }
