    public new IEnumerator<LaneConfigElement> GetEnumerator()
            {
                int count = base.Count;
                for (int i = 0; i < count; i++)
                {
                    yield return base.BaseGet(i) as LaneConfigElement;
                }
            }
