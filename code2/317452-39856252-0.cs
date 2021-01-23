            var A = new List<int>() { 1,2,3,4 };
            var B = new List<int>() { 1, 5, 6, 7 };
           var a= A.Except(B).ToList();
            // outputs List<int>(2) { 2,3,4 }
           var b= B.Except(A).ToList();
            // outputs List<int>(2) { 5,6,7 }
           var abint=  B.Intersect(A).ToList();
            // outputs List<int>(2) { 1 }
