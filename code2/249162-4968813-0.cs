                //HACK: to ensure that the tabpage draws correctly (the border will get clipped and
                // and gradient fill will match correctly with the tabcontrol).  Unfortunately, there is no good way to determine
                // the padding used on the tabpage.
                // I would like to use the following below, but GetMargins is busted in the theming API:
                //VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);
                //Padding themePadding = visualStyleRenderer.GetMargins(e.Graphics, MarginProperty.ContentMargins);
