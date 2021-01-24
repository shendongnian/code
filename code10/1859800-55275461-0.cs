    using NUnit.Framework;
    using UnityEngine;
    
    namespace Tests
    {
      public class FromJson
      {
        [Test]
        public void Flat()
        {
          string json = "{\"foo\":\"bar\"}";
          Flat deserialized = JsonUtility.FromJson<Flat>(json);
          Assert.AreEqual(deserialized.foo, "bar");
          var reserialized = JsonUtility.ToJson(deserialized);
          Assert.AreEqual(json, reserialized);
        }
    
        [Test]
        public void Nested()
        {
          string json = "{\"foo\":{\"foo\":\"bar\"}}";
          Nested deserialized = JsonUtility.FromJson<Nested>(json);
          Assert.AreEqual(deserialized.foo.foo, "bar");
          var reserialized = JsonUtility.ToJson(deserialized);
          Assert.AreEqual(json, reserialized);
        }
      }
    }
    
    [System.Serializable]
    class Foo
    {
      public string bar;
    }
    
    [System.Serializable]
    public class Flat
    {
      public string foo;
    }
    
    [System.Serializable]
    public class Nested
    {
      public Foo2 foo;
    }
    
    [System.Serializable]
    public class Foo2
    {
      public string foo;
    }
