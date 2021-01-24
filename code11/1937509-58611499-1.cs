using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CompleteCameraController : MonoBehaviour
{
    public Transform Player;
    public float distanceFromObject = 3f;
    void Update()
    {
        Vector3 lookOnObject = Player.position - transform.position;
        lookOnObject = Player.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        playerLastPosition = Player.position - lookOnObject.normalized * distanceFromObject;
        playerLastPosition.y = Player.position.y + distanceFromObject / 2;
        transform.position = playerLastPosition;
    }
When the ball moves left or right, the camera will follow the same angle as the ball moves towards.
