    public static List<GameObject> GetObject(int @object)
    {
        switch(@object)
        {
            case HUMAN:
                return humans;
            case ZOMBIE:
                return zombies;
            case PSG:
                return new List<GameObject>() { psgObject };
            default:
                Debug.Log("GetObject() method error");
                return null;
        }
    }
