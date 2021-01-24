using System.Linq.Dynamic;
    List<customobj> items = new List<customobj> {
                new customobj{num=1,text="Ab"},
                new customobj{num=2},
                new customobj{num=3,text="cc"},
                new customobj{num=4,text="dd"},
                new customobj{num=5,text="ee"},
            };
            var item = items.AsQueryable().OrderBy("text DESC");
        
