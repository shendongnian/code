    private void SomeOtherMethod()
    {
         // get a reference to the Move method
         _myMoveDelegate = Move;
         // or, alternatively the longer version:
         // _myMoveDelegate = new MoveDelegate(Move);
         // works for static methods too
         _myMoveDelegate = MoveStatic;
         // and then simply call the Move method indirectly
         _myMoveDelegate(someActor, someDirection);
    }
