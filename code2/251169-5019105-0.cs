    private void FieldItemGrid_PreviewMouseMove(object sender, MouseEventArgs e) {
        if (_isDown) {
            if ((_isDragging == false)) {
                /*Add Adorner to Item that is being dragged*/
                DragStarted(e.GetPosition(this));
            }
            if (_selectedElement != null) {
                DragDrop.AddGiveFeedbackHandler(Element, OnGiveFeedback);
                try {
                    /*Begin Drag Operation*/
                    DragDrop.DoDragDrop(_selectedElement, _selectedElement, DragDropEffects.Move);
                }
                finally {
                    DragDrop.RemoveGiveFeedbackHandler(Element, OnGiveFeedback);
                }
            }
    
            /*The following code is not executed until the dragged item is released*/
            if (_isDragging) {
                /*Update Current Position of Mouse to update adorner position*/
                DragMoved(e.GetPosition(this));
            }
        }
    }
    
    private void OnGiveFeedback(object sender, GiveFeedbackEventArgs e) {
        // Update adorner location here
    }
