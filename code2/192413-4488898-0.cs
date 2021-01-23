     public TreeChangedCommand(TreeModel model, ISelectTreeView selectTreeView,Expression<Func<object>> propertyExpression )
        {
            _model = model;
            _selectTreeView = selectTreeView;
    
            var body = propertyExpression.Body as MemberExpression;
            _propertyName = body.Member.Name;
    
        }
