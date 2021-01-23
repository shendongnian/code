    public void MoveItemUp( int index ) {
        MyController c = _myController[index];
        _myController.RemoveAt( index );
        _myController.Insert( index - 1, c );
    }
    public void MoveItemDown( int index ) {
        MyController c = _myController[index];
        _myController.RemoveAt( index );
        _myController.Insert( index + 1, c );
    }
