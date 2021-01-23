    public class Pane : HideableChildViewModel, IPane
    {
        private IViewModel _model;
        private bool _isFree = true;
        private string _name;
        private double _coordinateX;
        private double _coordinateY;
        private double _width = 200.0;
        private double _height = 400.0;
        private ICommand _closeCommand;
        private ICommand _dragCommand;
        private ICommand _resizeCommand;
        /// <summary>
        /// Initializes a new instance of the Pane class.
        /// </summary>
        /// <param name="parent">The parent view model</param>
        /// <param name="parentPropertySelector">Selector of the parent property</param>
        /// <param name="model">VM to place within the pane</param>
        public Pane(
            IViewModel parent, 
            Expression<Func<object>> parentPropertySelector,
            IViewModel model)
            : base(parent, parentPropertySelector)
        {
            this.Model = model;
            this._dragCommand = new DragPaneCommand();
            this._resizeCommand = new ResizeCommand();
            if (model != null && model is ICloseableVM)
            {
                this._closeCommand = new ClosePaneCommand();
            }
            else
            {
                this._closeCommand = new HideCommand();
            }
        }
        #region Properties
        /// <summary>
        /// Gets or sets VM to place within the pane
        /// </summary>
        public IViewModel Model
        {
            get 
            {
                return this._model; 
            }
            set 
            {
                if (this._model != value)
                {
                    this._model = value;
                    this.RaisePropertyChanged(() => this.Model);
                }
            }
        }
        /// <summary>
        /// Gets or sets name of the pane
        /// </summary>
        [LayoutSettings(IsKey = true)]
        public string Name
        {
            get 
            {
                return this._name; 
            }
            set 
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.RaisePropertyChanged(() => this.Name);
                }
            }
        }
        /// <summary>
        /// Gets or sets X coordinate
        /// </summary>
        [LayoutSettings]
        public double X
        {
            get 
            {
                return this._coordinateX; 
            }
            set 
            {
                if (this._coordinateX != value)
                {
                    this._coordinateX = value;
                    this.RaisePropertyChanged(() => this.X);
                }
            }
        }
        /// <summary>
        /// Gets or sets Y coordinate
        /// </summary>
        [LayoutSettings]
        public double Y
        {
            get 
            {
                return this._coordinateY; 
            }
            set 
            {
                if (this._coordinateY != value)
                {
                    this._coordinateY = value;
                    this.RaisePropertyChanged(() => this.Y);
                }
            }
        }
        /// <summary>
        /// Gets or sets width
        /// </summary>
        [LayoutSettings]
        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if (this._width != value)
                {
                    this._width = value;
                    this.RaisePropertyChanged(() => this.Width);
                }
            }
        }
        /// <summary>
        /// Gets or sets height
        /// </summary>
        [LayoutSettings]
        public double Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if (this._height != value)
                {
                    this._height = value;
                    this.RaisePropertyChanged(() => this.Height);
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether pane is free
        /// </summary>
        public bool IsFree
        {
            get
            {
                return this._isFree;
            }
            set
            {
                if (this._isFree != value)
                {
                    this._isFree = value;
                    this.OnIsFreeChanged(this._isFree);
                    this.RaisePropertyChanged(() => this.IsFree);
                }
            }
        }
        #endregion
        #region Commands
        /// <summary>
        /// Gets command for pane closing
        /// </summary>
        public ICommand CloseCommand
        {
            get { return this._closeCommand; }
        }
        /// <summary>
        /// Gets command for pane dragging
        /// </summary>
        public ICommand DragCommand
        {
            get { return this._dragCommand; }
        }
        /// <summary>
        /// Gets command for pane resize
        /// </summary>
        public ICommand ResizeCommand
        {
            get { return this._resizeCommand; }
        }
        #endregion
        private void OnIsFreeChanged(bool isFree)
        {
            if (!isFree)
            {
                return;
            }
            IDockContainer oContainer = ((IChildViewModel)((IChildViewModel)this.Parent).Parent).Parent as IDockContainer;
            if (oContainer != null)
            {
                this.SetParent(oContainer, () => oContainer.FreeItems);
            }
        }
    }
