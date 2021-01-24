    void Update()
        {
            for (int i = 0; i < meshRenderer.sharedMaterials.Length; i++)
            {
                if (meshRenderer.sharedMaterials[i].name == "replaceableMat")
                {
                    // Replace with TestMaterial
                    renderer.sharedMaterials[i] = TestMaterial
                }
            }
        }
