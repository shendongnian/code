    public class FactoryEntity<TEntity> where TEntity : Entity, new()
    {
	private TEntity _Entity;
        public FactoryEntity()
        {
            _Entity = new TEntity();
        }
	public TEntity Build()
        {
            if (_Entity.IsValid())
                throw new Exception("_Entity.Id");
            return _Entity;
        }
	public IFactoryEntity<TEntity> AssociateWithEntity<TProperty>(Expression<Func<TEntity, TProperty>> foreignEntity, TProperty instanceEntity) where TProperty : Entity
        {
            if (instanceEntity == null || instanceEntity.IsTransient())
                throw new ArgumentNullException();
            SetObjectValue<TEntity, TProperty>(_Entity, foreignEntity, instanceEntity);
            return this;
        }
	private void SetObjectValue<T, TResult>(object target, Expression<Func<T, TResult>> expression, TResult value)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;
            var newValue = Convert.ChangeType(value, value.GetType());
            propertyInfo.SetValue(target, newValue, null);
        }
    }
