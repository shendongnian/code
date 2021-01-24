     @page  "/test-loop"
    
    <h3>TestLoop</h3>
    @foreach (var test in TestList)
    {
        <div>Id: @test.Id</div>
        <textarea @bind="test.TextAreaValue">
    
        </textarea>
    }
    
    
    @* To show it's working: *@/
    @foreach (var test in TestList)
    {
        <div>Id: @test.Id</div>
        @test.TextAreaValue
    }
    <br />
    
    @* Get The values on an event test *@
    <button @onclick="ButtonClicked">
        Test
    </button>
    @code {
    
        List<TestObject> TestList = new List<TestObject>();
    
        protected override void OnInitialized()
        {
            base.OnInitialized();
            TestList.Add(new TestObject()
            {
                Id = 1
            });
            TestList.Add(new TestObject()
            {
                Id = 2
            });
            TestList.Add(new TestObject()
            {
                Id = 3
            });
        }
    
        public void ButtonClicked()
        {
            //TestList has the values of each textarea in it
        }
    
        public class TestObject
        {
            public int Id { get; set; }
            public string TextAreaValue { get; set; }
        }
    }
