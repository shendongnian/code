                    public bool IsEnabledBrand
                    {
                        get => isEnabledBrand;
                        set
                        {
                            if (isEnabledBrand != value)
                            {
                                isEnabledBrand = value;
                                NotifyPropertyChanged();
                            }
                        }
                    }
