    public List<Recipe> RecipeList
    {
        get { return this._recipeList; }
        private set
        {
            this._recipeList = value;
            OnPropertyChanged("RecipeList");
        }
    }
