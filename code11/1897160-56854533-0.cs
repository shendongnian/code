using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable] //THIS! On all your classes!!!
public class RootObject
{
    public PlusCode plus_code;
    public List<Result> results;
    public string status;
    public static RootObject CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<RootObject>(jsonString);
    }
}
[Serializable]
public class PlusCode
{
    public string compound_code;
    public string global_code;
}
[Serializable]
public class AddressComponent
{
    public string long_name;
    public string short_name;
    public List<string> types;
}
[Serializable]
public class Northeast
{
    public double lat;
    public double lng;
}
[Serializable]
public class Southwest
{
    public double lat;
    public double lng;
}
[Serializable]
public class Bounds
{
    public Northeast northeast;
    public Southwest southwest;
}
[Serializable]
public class Location
{
    public double lat;
    public double lng;
}
[Serializable]
public class Northeast2
{
    public double lat;
    public double lng;
}
[Serializable]
public class Southwest2
{
    public double lat;
    public double lng;
}
[Serializable]
public class Viewport
{
    public Northeast2 northeast;
    public Southwest2 southwest;
}
[Serializable]
public class Geometry
{
    public Bounds bounds;
    public Location location;
    public string location_type;
    public Viewport viewport;
}
[Serializable]
public class PlusCode2
{
    public string compound_code;
    public string global_code;
}
[Serializable]
public class Result
{
    public List<AddressComponent> address_components;
    public string formatted_address;
    public Geometry geometry;
    public string place_id;
    public List<string> types;
    public PlusCode2 plus_code;
}
