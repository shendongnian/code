        var postTemp = (from p in posts
                            let PostId = p.PostID
                            let ProductId = ""
                            let PostDes = p.PostDescription
                            let ProductDes = ""
                            select new {PostId, ProductId, PostDes, ProductDes }
                            ).ToList();
            var productsTemp = (from p in products
                                let PostId = ""
                                let ProductId = p.BusinessId
                                let PostDes = ""
                                let ProductDes = p.ProductDescription
                                select new{ PostId, ProductId, PostDes,ProductDes }).ToList();
            var allResidents = postTemp.Union<object>(productsTemp).ToList();
