    public float Intensity = .1f; //default value
    void SetColor()
    {
        gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor") * Intensity;
    }
