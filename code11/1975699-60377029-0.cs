    @page "/dropdownlist/overview"
    @page "/dropdownlist/index"
    
    @using TelerikBlazorDemos.Shared
    
    <div class="example-box-wrapper">
        <div class="example">
            <div class="mb-4">T-Shirt size:</div>
            <TelerikDropDownList Data="@Data"
                                 @bind-Value=@SelectedSizeMetric
                                 PopupHeight=""
                                 DefaultText="Select your T-shirt size"
                                 ValueField="SizeMetric" TextField="SizeText">
            </TelerikDropDownList>
        </div>
    
        <div class="ml-4">
            Selected Size Number: <strong>@SelectedSizeMetric</strong>
        </div>
    </div>
    
    @code  {
        public IEnumerable<Size> Data { get; set; }
        public bool AllowCustom { get; set; } = true;
        public int? SelectedSizeMetric { get; set; }
        public string SelectedSize { get; set; }
    
        public class Size
        {
            public string SizeText { get; set; }
            public int? SizeMetric { get; set; }
        }
    
        protected override void OnInitialized()
        {
            List<Size> sizes = new List<Size>();
    
            sizes.Add(new Size()
            {
                SizeText = "X-Small",
                SizeMetric = 3
            });
    
            sizes.Add(new Size()
            {
                SizeText = "Small",
                SizeMetric = 6
            });
    
            sizes.Add(new Size()
            {
                SizeText = "Medium",
                SizeMetric = 8
            });
    
            sizes.Add(new Size()
            {
                SizeText = "Large",
                SizeMetric = 10
            });
    
            sizes.Add(new Size()
            {
                SizeText = "X-Large",
                SizeMetric = 12
            });
    
            Data = sizes.AsQueryable();
            base.OnInitialized();
        }
    }
