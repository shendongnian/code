        LazyProperty<Color> _EyeColor = new LazyProperty<Color>();
        public Color EyeColor
        { 
            get 
            {
                return (_EyeColor.Value(() => SomeCPUHungaryMethod()));
            } 
        }
