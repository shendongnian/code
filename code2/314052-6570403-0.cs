    interface IField 
    { 
    object Data{get;set;}
    }
    interface IField<T> : IField
    {
    T TypedObject{get;set;}
    }
