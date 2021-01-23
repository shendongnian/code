        public override void AddOrUpdate(CustomCaseSearchCriteria entity)
        {
            var duplicateEntityCheck = GetSingleByUniqueConstraint(entity.UserCode, entity.FilterName);
            if (duplicateEntityCheck != null)
            {
                duplicateEntityCheck.Overwrite(entity);
                base.Update(duplicateEntityCheck);
            }
            else
                base.Add(entity);
        }
        public virtual CustomCaseSearchCriteria GetSingleByUniqueConstraint(string userCode, string filterName)
        {
            return GetAllInternal().SingleOrDefault(sc => sc.UserCode == userCode && sc.FilterName == filterName);
        }
