    public partial class Database1Entities
    {
        private struct ObjectContextProperty { }
        partial void OnContextCreated()
        {
            this.ObjectMaterialized += (_, e) =>
            {
                e.Entity.GetConnectedProperty<Database1Entities, ObjectContextProperty>().Set(this);
            };
            this.ObjectStateManager.ObjectStateManagerChanged += (_, e) =>
            {
                if (e.Action == CollectionChangeAction.Add)
                {
                    e.Element.GetConnectedProperty<Database1Entities, ObjectContextProperty>().Set(this);
                }
                else if (e.Action == CollectionChangeAction.Remove)
                {
                    e.Element.GetConnectedProperty<Database1Entities, ObjectContextProperty>().Set(null);
                }
            };
        }
        /// <summary>
        /// Gets the object context for the entity. Returns <c>null</c> if the entity is detached.
        /// </summary>
        /// <param name="entity">The entity for which to return the object context.</param>
        public static Database1Entities FromEntity(EntityObject entity)
        {
            return entity.GetConnectedProperty<Database1Entities, ObjectContextProperty>().GetOrConnect(null);
        }
    }
