    <ul>
        @foreach (var item in items)
        {
             <li class="c-sidebar-nav-item c-sidebar-nav-dropdown @item.DropdownClass" @onclick="@(() => item.MenuDroppedDown = !item.MenuDroppedDown)" >click me</li>
        }
    </ul>
    @code{
    bool MenuDroppedDown = true;
    string DropdownClass => MenuDroppedDown ? "c-show" : "";
    List<LiTag> items = Enumerable.Range(1, 10).Select(i => new LiTag { ID = i }).ToList();
    public class LiTag
    {
        public int ID { get; set; }
        public bool MenuDroppedDown { get; set; }
        public string DropdownClass => MenuDroppedDown ? "c-show" : "";
    }
    }
