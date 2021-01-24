        it is almost same with marco's answer. 
        
        --make a view model
        
        public class CountryViewModel
        {
            public string Name { get; set;}
            public double Result {get; set;}
        }
        --at the controller need put 'ViewModel Name'
        var list1 = list.GroupBy(y => y.columnName1)
                       .Select(group => new CountryViewModel
                        {
                            Name = group.Key,
                            Result = group.Sum(x => x.columnName2)
                        })
                        .ToList();
        
        
         return View(list1);
    
    --foreach was same (i didn't need @model syntax on the top in this case.
    @foreach (var item in Model)
    {
       <tr>
          <td>@item.Name</td>
          <td>@item.Result</td>
       </tr>
    }
