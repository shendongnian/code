        public static object GetSubjectHierarchyJSON(Func<vwHierarchicalSubject, bool> InitialPredicate, HierarchicalSubjectDAO DAO, int ItemType) {
            List<LINQLayer.vwHierarchicalSubject> TempSource = DAO.GetAll(DAO.UserID, ItemType).
                OrderBy(V => V.ParentSubjectName).ThenBy(V => V.LevelNumber).ThenBy(V => V.SubjectName).ToList();
            var result = new List<object>();
            foreach (vwHierarchicalSubject V in TempSource.Where(InitialPredicate).OrderBy(v => v.SubjectName))
                result.Add(BuildJSON(V, TempSource));
            return result;
        }
        private static object BuildJSON(vwHierarchicalSubject V, List<vwHierarchicalSubject> TempSource) {
            IEnumerable<vwHierarchicalSubject> Children =
                TempSource.Where(x => x.ParentID.HasValue && x.ParentID.Value == V.id).OrderBy(v => v.SubjectName);
            
            int id = V.id;
            string subText = V.SubjectName.Replace("&", "&amp;");
            if (Children.Count() == 0)
                return new { id = V.id, text = subText, children = new List<object>(), expanded = true };
            else {
                var result = new { id = V.id, text = subText, children = new List<object>() };
                foreach (vwHierarchicalSubject vElement in Children)
                    result.children.Add(BuildJSON(vElement, TempSource));
                return result;
            }
        }
