    @using System.Linq
    @using System.Reflection
    @using System.ComponentModel.DataAnnotations
    
    @typeparam TItem
    
    <label for="@fortag">@label</label>
    
    @code {
        [Parameter] public string aspfor { get; set; }        
    
        private string label => GetDisplayName(aspfor);
    
        private string fortag => aspfor;
    
        private string GetDisplayName(string propertyname)
        {
            MemberInfo myprop = typeof(TItem).GetProperty(propertyname) as MemberInfo;
            var dd = myprop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return dd?.Name ?? "";
        }
    
    }
