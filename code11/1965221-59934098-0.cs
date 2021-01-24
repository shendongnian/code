    public void MouseUp(MouseButtons mouseButtons, IContextMenuProvider contextMenuProvider) {
    	if((mouseButtons & MouseButtons.RightButton) == MouseButtons.RightButton) {
    		ShowContextMenu(contextMenuProvider);  //Remove this
    	}
    }
