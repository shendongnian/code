    class ParentCollection<T> where T : new(),Parent {
           public T Add() {
            var item = new T();
             Add(item);
             return item;
           }
        }
