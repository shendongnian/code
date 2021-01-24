    public SaveState(Vector3 pos, Quaternion rot, Vector3 sca)
    {
        // Since structs are never null
        // you don't need to create new ones
        position.V3 = pos;
        rotation.Qua = rot;
        scale.V3 = sca;
    }
