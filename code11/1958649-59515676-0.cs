    @using WbotV2.Data
    @using System
    @using System.Collections
    @using System.Reflection
    @typeparam TItem
    
    <tr>
        @foreach (var datum in Data)
        {
            <td>@datum</td>
        }
        <td><button class="btn btn-success">Edit</button></td>
        <td>@ChildContent</td>
    </tr>
    
    
    @code {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public EventCallback<TItem> Delete { get; set; }
    
        [Parameter]
        public TItem Item { get; set; }
    
        public List<string> Data;
        public bool Editable = false;
        protected override void OnInitialized()
        {
            Data = GetData(Item);
        }
    
        public static List<string> GetData(TItem instance)
        {
            List<string> ret = new List<string>();
            FieldInfo[] infos = typeof(TItem).GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);
            foreach (FieldInfo info in infos)
            {
                ret.Add(info.GetValue(instance).ToString());
            }
            return ret;
        }
    }
