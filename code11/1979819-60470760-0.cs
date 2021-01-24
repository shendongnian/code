if(Input.GetMouseButtonDown(0)) {
    mouseWasPressedOverObject = IsMouseOverObject();
} else if(Input.GetMouseButtonUp(0)) {
    if(mouseWasPressedOverObject && IsMouseOverObject()) {
        //Object clicked
    }
    mouseWasPressedOverObject = false;
}
