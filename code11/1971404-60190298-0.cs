        Vector3 pos;
        GGVPointer pointer = PointerUtils.GetPointer<GGVPointer>(Handedness.Right);
        if(pointer != null)
        {
            pos = pointer.Position;
        }
