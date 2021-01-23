    using(var myEnum = aList.GetEnumerator()){
        while(myEnum.MoveNext()){
            myEnum.Current.SomeAction();
        }
    }
