         public class MyViewModel
    {
        public ObservableCollection<MyModel> myModels { get; set; }
        public MyViewModel()
        {
            myModels = new ObservableCollection<MyModel>();
            myModels.Add(new MyModel() { Answer=1, DropdownOptions= new int[]{ 1, 2 ,3, 4 }, IndentPadding=3, IsVisible=true, RowHeight=30, Text="test1" });
            myModels.Add(new MyModel() { Answer = 2, DropdownOptions = new int[] { 1, 2, 3, 4 }, IndentPadding = 3, IsVisible = true, RowHeight = 30, Text = "test2" });
            myModels.Add(new MyModel() { Answer = 1, DropdownOptions = new int[] { 1, 2, 3, 4 }, IndentPadding = 3, IsVisible = true, RowHeight = 30, Text = "test3" });
            myModels.Add(new MyModel() { Answer = 3, DropdownOptions = new int[] { 1, 2, 3, 4 }, IndentPadding = 3, IsVisible = true, RowHeight = 30, Text = "test4" });
            myModels.Add(new MyModel() { Answer = 2, DropdownOptions = new int[] { 1, 2, 3, 4 }, IndentPadding = 3, IsVisible = true, RowHeight = 30, Text = "test5" });
            myModels.Add(new MyModel() { Answer = 4, DropdownOptions = new int[] { 1, 2, 3, 4 }, IndentPadding = 3, IsVisible = true, RowHeight = 30, Text = "test6" });
    }
    }
