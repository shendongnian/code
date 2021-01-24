public void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        InputSystem?.RaiseOnInputDown(
            InputSource,
            Handedness.Right,
            selectAction
            );
    }
    if (Input.GetMouseButtonUp(0))
    {
        InputSystem?.RaiseOnInputUp(
            InputSource,
            Handedness.Right,
            selectAction
            );
    }
}
Here is the full code for a component will raise input down and up events that will allow you to simulate pinch and drag + move using just the mouse:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;
public class SimulateSelectOnClick : MonoBehaviour
{
    private IMixedRealityInputSystem inputSystem = null;
    protected IMixedRealityInputSystem InputSystem
    {
        get
        {
            if (inputSystem == null)
            {
                MixedRealityServiceRegistry.TryGetService<IMixedRealityInputSystem>(out inputSystem);
            }
            return inputSystem;
        }
    }
    private IMixedRealityInputSource inputSource;
    private MixedRealityInputAction selectAction;
    private IMixedRealityInputSource InputSource
    {
        get
        {
            if (inputSource != null)
            {
                return inputSource;
            }
            inputSource = new BaseGenericInputSource("SimulateSelect",
               new IMixedRealityPointer[] { InputSystem.GazeProvider.GazePointer }, InputSourceType.Hand) ;
            return inputSource;
        }
    }
    public void Start()
    {
        var inputActions = MixedRealityToolkit.Instance.ActiveProfile.InputSystemProfile.InputActionsProfile.InputActions;
        selectAction = new MixedRealityInputAction();
        for (int i = 0; i < inputActions.Length; i++)
        {
            if (inputActions[i].Description.Equals("select", StringComparison.CurrentCultureIgnoreCase))
            {
                selectAction = inputActions[i];
            }
        }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InputSystem?.RaiseOnInputDown(
                InputSource,
                Handedness.Right,
                selectAction
                );
        }
        if (Input.GetMouseButtonUp(0))
        {
            InputSystem?.RaiseOnInputUp(
                InputSource,
                Handedness.Right,
                selectAction
                );
        }
    }
}
