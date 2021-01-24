    <table class="table table-hover">
       <thead>
        <tr>
            <th>Select</th>
            <th>Number</th>
            <th>Text</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var row in rows)
        {
            
        <tr @onclick="@(() => { row.Selected = !row.Selected; 
            Console.WriteLine(row.Selected.ToString()); })">
             <td><input type="checkbox" checked="@row.Selected" 
        @onchange="@((args) => { row.Selected = (bool)
        args.Value; Console.WriteLine(row.Selected.ToString());} )" /></td>
            <td>@row.Number</td>
            <td>@row.Text</td>
        </tr>
        }
     </tbody>
     </table>
     @code
     {
        List<Row> rows = Enumerable.Range(1, 10).Select(i => new Row
         {
        Selected =
             false,
        Number = i,
        Text = $"Item {i}"
        }).ToList();
       private class Row
     {
        public bool Selected { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
    }
 
