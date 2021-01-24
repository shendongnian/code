public static IEnumerable<MyEntity> GetBreadcrumbs(IEnumerable<MyEntity> entities, int? ParentNodeId = null)
        {
            
            var childNodes = entities.Where(x => x.ParentCategoryId == ParentNodeId);
            foreach (var currentNode in childNodes)
            {
                var parent = entities.SingleOrDefault(x => x.Id == currentNode.ParentCategoryId);
                var childrens = entities.Where(x => x.ParentCategoryId == currentNode.Id);
                currentNode.FullBreadcrumb = string.Format("{0}{1}", (parent == null ? null : parent.FullBreadcrumb + " > "), currentNode.Name);
                yield return currentNode;
                foreach (var trail in GetBreadcrumbs(entities, currentNode.Id))
                {
                    yield return trail;
                }
            }
        }
