    using System;
    using System.Reflection;
    
    public enum EffectType
    {
    	A,
    	B
    }
    
    public class Effect
    {
    	public EffectType Type { get; set; }
    }
    
    public class EffectResult
    {
    	public EffectType Type { get; set; }
    	public bool Success { get; set; }
    
    	public EffectResult(EffectType type, bool success)
    	{
    		Type = type;
    		Success = success;
    	}
    }
    
    public class EffectMethods
    {
    	public static EffectResult Blend(Effect effect)
    	{
    		bool success = true;
    		return new EffectResult(effect.Type, success);
    	}
    }
    
    public static class Program
    {
    	public static void Main()
    	{
    		var methods = typeof (EffectMethods).GetMethods(BindingFlags.Public | BindingFlags.Static);
    
    		var result = methods[0].Invoke(null, new object[] { new Effect { Type = EffectType.A } });
    
    		Console.WriteLine(result);
    	}
    }
