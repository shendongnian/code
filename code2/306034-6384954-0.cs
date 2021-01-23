        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(objScrollViewer);
            if (mousePos.X <= objScrollViewer.ViewportWidth && mousePos.Y <
                objScrollViewer.ViewportHeight)
            {
                objScrollViewer.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(objScrollViewer);
            }
            FrameworkElement ctrl = (e.OriginalSource as FrameworkElement);
            if (ctrl != null)
            {
                switch (ctrl.DataContext.GetType().ToString())
                {
                    case "GE.GNF.ACUMEN.Library.SIMULATOR_BUNDLE_NODAL_DATA":
                        objCoreViewer.SelectedItem = ctrl.DataContext as SIMULATOR_BUNDLE_NODAL_DATA;
                        break;
                    case "GE.GNF.ACUMEN.Library.SIMULATOR_CONTROL_BLADE_NODAL_DATA":
                        objCoreViewer.SelectedItem = ctrl.DataContext as SIMULATOR_CONTROL_BLADE_NODAL_DATA;
                        break;
                    default:
                        break;
                }
            }
        }
