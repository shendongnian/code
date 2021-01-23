        class PreventOverridingOnSameIds : IMappingAction<ParentViewModel, Parent>
        {
            public void Process (ParentViewModel source, Parent destination)
            {
                var matching_ids = source.Children.Select(c => c.Id).Intersect(destination.Children.Select(d => d.Id));
                foreach (var id in matching_ids)
                {
                    source.Children = source.Children.Where(c => c.Id != id).ToList();
                }
            }
        }
