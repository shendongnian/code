            dynamic acadApp = Application.AcadApplication;
            acadApp.ZoomExtents();
            var selectionResult = ed.SelectCrossingWindow(
                new Point3d(2, 2, 0), new Point3d(10, 8, 0));
            acadApp.ZoomPrevious();
            if (selectionResult.Status == PromptStatus.OK)
            {
                Application.ShowAlertDialog(
                    "Number of objects selected: " + selectionResult.Value.Count);
            }
