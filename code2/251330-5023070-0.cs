        /// <summary>
        /// Reattach and mark specific fields on the entity as modified.
        /// </summary>
        /// <param name="objectContext">The context to attach the entity object.</param>
        /// <param name="setName">The string representation of the set that should contain the given entity object.</param>
        /// <param name="entity">The detached entity object.</param>
        /// <param name="modifiedFields">Names of fields that have been modified.</param>
        public static void AttachAsModified(this ObjectContext objectContext, string setName, object entity,
                                            IEnumerable<String> modifiedFields)
        {
            objectContext.AttachTo(setName, entity);
            ObjectStateEntry stateEntry = objectContext.ObjectStateManager.GetObjectStateEntry(entity);
            foreach (String field in modifiedFields)
            {
                stateEntry.SetModifiedProperty(field);
            }
        }
