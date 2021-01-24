    @foreach (var item in items)
    {
         <button class="@item.Class" @onclick="@(()=> item.Shown = 
                                               !item.Shown)"></button>
     }
     @code {
    List<SelectedButton> items = Enumerable.Range(1, 5).Select(i => new 
                    SelectedButton { ID = i, Shown = false }).ToList();
    public class SelectedButton
    {
        public int ID { get; set; }
        public bool Shown { get; set; }
        public string Class => Shown ? "red" : "";
    }
    }
