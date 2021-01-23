    private void SomeOtherMethod()
    {
         // get a reference to the Move method
         _myMoveDelegate = Move;
         // or, alternatively the longer version:
         // _myMoveDelegate = new MoveDelegate(Move);
         // and then simply call the Move method indirectly
         _myMoveDelegate(someActor, someDirection);
    }
