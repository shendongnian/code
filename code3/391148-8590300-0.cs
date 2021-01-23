    private new bool Enabled
            {
                get { return _enabled; }
                set
                {
                    foreach (System.Windows.Forms.Control c in this.Controls)
                    {
                        if (c is SomeTypeThatShouldBeExcluded)
                            continue;
                        c.Enabled = value;
                    }
                    _enabled = value;
                }
            }
