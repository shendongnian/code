            public bool AreSettingChanged()
            {
                bool changed = false;
                objRpmButtonHolder.RpmButtonCollection.ForEach(btn
                    =>
                    {
                        if (btn.IsChanged)
                            changed = true;
                    });
                return changed;
            }
