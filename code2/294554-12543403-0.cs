    var setZOrderMethodInfo = adornerLayer.GetType().GetMethod("SetAdornerZOrder", 
          System.Reflection.BindingFlags.NonPublic |  
          System.Reflection.BindingFlags.Instance);     
    setZOrderMethodInfo.Invoke(adornerLayer, new object[] { adorner1, 0 });     
    setZOrderMethodInfo.Invoke(adornerLayer, new object[] { adorner2, 1 });
