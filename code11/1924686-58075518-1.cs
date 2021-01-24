    @code {
    [Parameter]
    public IList<MyModel> Items { get; set; }
    public async void ClickForTestRow(ElementReference row)
    {
        await JsRuntime.InvokeAsync<object>("updateBackgroundColor", row, "red");
    }
    public class MyModel
    {
        public ElementReference Row { get; set; }
        public string Name { get; set; }
    }
    }
//----------------
    <script type="text/javascript">
        function updateBackgroundColor(row) {
            row.bgColor = 'red';
        }
    </script>
