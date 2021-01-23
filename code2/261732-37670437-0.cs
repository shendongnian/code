    public PIPoint SearchForPoint()
        {
            TagSearch searchDialog = new TagSearch();
            PointList result = searchDialog.Show(null, TagSearchOptions.tsoptSingleSelect);
            if (result.Count > 0)
            {
                return result[1];
            }
            return null;
        }
