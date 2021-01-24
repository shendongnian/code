            var above = (from mainTable in table1
                join table3 in table2 on mainTable.someId equals table3.someId
                where table3.Column1 == Column1 && mainTable.SomeDouble >= myValue
                orderby mainTable.SomeDouble
                select new {SomeInt = mainTable.SomeInt, SomeDouble = mainTable.SomeDouble}).FirstOrDefault();
            var below = (from mainTable in table1
                join table3 in table2 on mainTable.someId equals table3.someId
                where table3.Column1 == Column1 && mainTable.SomeDouble < myValue
                orderby mainTable.SomeDouble descending 
                select new {SomeInt = mainTable.SomeInt, SomeDouble = mainTable.SomeDouble}).FirstOrDefault();
            int SomeInt;
            if (above == null)
                SomeInt = below.SomeInt;
            else if (below == null)
                SomeInt = above.SomeInt;
            else if (Math.Abs(below.SomeDouble - myValue) <= Math.Abs(above.SomeDouble - myValue))
                SomeInt = below.SomeInt;
            else 
                SomeInt = above.SomeInt;
