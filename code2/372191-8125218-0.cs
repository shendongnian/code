    private static void ProcessDraggedHitTest(
            Window window)
        {
            var CursorPos = GetCursorPos();
            var MousePosition = Mouse.GetPosition(window);
            IDragTarget hitControl = null;
            var hitTestResult = VisualTreeHelper.HitTest(window, new Point(CursorPos.X + MousePosition.X, CursorPos.Y + MousePosition.Y));
            if (hitTestResult != null)
            {
                var parent = hitTestResult.VisualHit as DependencyObject;
                while (parent != null)
                {
                    hitControl = parent as IDragTarget;
                    if (tileOutControl != null)
                        break;
                    else
                        parent = VisualTreeHelper.GetParent(parent);
                }
                if (hitControl != null)
                    DragOver(hitControl, _draggedItem);
            }
        }
