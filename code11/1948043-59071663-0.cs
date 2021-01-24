    void OnValidate()
    {
        //Check if we are in the Editor, and the animationClip is getting change
        if (Application.isEditor && !Application.isPlaying && previousClip != animationClip)
        {
            previousClip = animationClip;
            m_checkPoints = new Vector3[10];
            int index = 0;
    
            //Taking the curves form the animation clip
            AnimationCurve curve;
            var curveBindings = AnimationUtility.GetCurveBindings(animationClip);
    
            //Going into each curves
            foreach (var curveBinding in curveBindings)
            {
                //Checking curve's name, as we only need those about the position
                if (curveBinding.propertyName == "m_LocalPosition.x")
                    index = 0;
                else if (curveBinding.propertyName == "m_LocalPosition.y")
                    index = 1;
                else if (curveBinding.propertyName == "m_LocalPosition.z")
                    index = 2;
                else
                    continue;
    
                //Get the curveform the editor
                curve = AnimationUtility.GetEditorCurve(animationClip, curveBinding);
    
                for (float i = 0; i < 10; i++)
                {
                    //Evaluate the curves at a given time
                    m_checkPoints[(int)i][index] = curve.Evaluate(animationClip.length * (i / 10f));
                }
            }
        }
    }
