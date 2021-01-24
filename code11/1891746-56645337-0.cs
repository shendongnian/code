    #define USE_CUSTOM_EDITOR
    
    using System.Linq;
    using UnityEngine;
    using UnityEngine.EventSystems;
    #if UNITY_EDITOR && USE_CUSTOM_EDITOR
    using UnityEditor;
    #endif
    
    public class LaserPointerController : MonoBehaviour
    {
        #region Inspector
    
        [Header("Pointer Settings")]
        [Tooltip("Should the LaserPointer origin have an offset to the controller position (in local coordinates)?")]
        [SerializeField] private bool useOffset;
        [SerializeField] private Vector3 offset = Vector3.zero;
    
        [Tooltip("The maximal distance of the laser pointer (in Unity Units)")]
        [SerializeField] private float maxPointerDistance = 5f;
    
        [Tooltip("Should the laser have a Collider attached?\nUseful for e.g. directly using OnTriggerEnter\n\nNote: This will use Physics.RaycastAll which is less efficient.")]
        [SerializeField] private bool useCollider;
        [Tooltip("Should the laser Collider be a trigger?\nHas to be disabled to e.g. use OnCollisionEnter")]
        [SerializeField] private bool colliderIsTrigger;
        [Tooltip("Should the laser additionally have a RigidBody?\nRequired for some types of collisions.")]
        [SerializeField] private bool useRigidBody;
    
        [Header("Style Settings")]
        [Tooltip("Should the laser change its Color when pressed")]
        [SerializeField] private bool changeColor;
        [Tooltip("Should the laser change its thickness when pressed")]
        [SerializeField] private bool changeThickness;
        [Tooltip("Color of the Laser in idle")]
        [SerializeField] private Color idleColor = Color.red;
        [Tooltip("Color of the beam when pressed")]
        [SerializeField] private Color pressedColor = Color.green;
        [Tooltip("Thickness of the laser beam")]
        [SerializeField] private float idleThickness = 0.005f;
        [Tooltip("Thickness of the laser beam when pressed")]
        [SerializeField] private float pressedThickness = 0.007f;
    
        [Header("Debug")]
        [SerializeField] private bool isPressed;
        [SerializeField] private Vector3 pointerPosition3D;
        [SerializeField] private Vector2 pointerPosition2D;
    
    #if UNITY_EDITOR && USE_CUSTOM_EDITOR
        [CustomEditor(typeof(LaserPointerController))]
        private class LaserPointerControllerEditor : Editor
        {
            private SerializedProperty useOffset;
            private SerializedProperty offset;
    
            private SerializedProperty maxPointerDistance;
    
            private SerializedProperty useCollider;
            private SerializedProperty colliderIsTrigger;
            private SerializedProperty useRigidBody;
    
            private SerializedProperty changeColor;
            private SerializedProperty changeThickness;
            private SerializedProperty idleColor;
            private SerializedProperty pressedColor;
            private SerializedProperty idleThickness;
            private SerializedProperty pressedThickness;
    
            private SerializedProperty _isPressed;
            private SerializedProperty pointerPosition3D;
            private SerializedProperty pointerPosition2D;
    
            private void OnEnable()
            {
                useOffset = serializedObject.FindProperty("useOffset");
                offset = serializedObject.FindProperty("offset");
    
                maxPointerDistance = serializedObject.FindProperty("maxPointerDistance");
                useCollider = serializedObject.FindProperty("useCollider");
                colliderIsTrigger = serializedObject.FindProperty("colliderIsTrigger");
                useRigidBody = serializedObject.FindProperty("useRigidBody");
    
                changeColor = serializedObject.FindProperty("changeColor");
                changeThickness = serializedObject.FindProperty("changeThickness");
                idleColor = serializedObject.FindProperty("idleColor");
                pressedColor = serializedObject.FindProperty("pressedColor");
                idleThickness = serializedObject.FindProperty("idleThickness");
                pressedThickness = serializedObject.FindProperty("pressedThickness");
    
                _isPressed = serializedObject.FindProperty("isPressed");
                pointerPosition3D = serializedObject.FindProperty("pointerPosition3D");
                pointerPosition2D = serializedObject.FindProperty("pointerPosition2D");
            }
    
            public override void OnInspectorGUI()
            {
                serializedObject.Update();
    
                DrawScriptField();
    
                EditorGUILayout.PropertyField(useOffset);
                if (useOffset.boolValue)
                {
                    EditorGUILayout.PropertyField(offset);
                    EditorGUILayout.Space();
                }
    
                EditorGUILayout.PropertyField(maxPointerDistance);
    
                EditorGUILayout.PropertyField(useCollider);
                if (useCollider.boolValue)
                {
                    EditorGUILayout.PropertyField(colliderIsTrigger);
                    EditorGUILayout.PropertyField(useRigidBody);
                }
                else
                {
                    colliderIsTrigger.boolValue = true;
                    useRigidBody.boolValue = false;
                }
    
                EditorGUILayout.PropertyField(changeColor);
                EditorGUILayout.PropertyField(changeThickness);
    
                EditorGUILayout.PropertyField(idleColor);
                if (changeColor.boolValue) EditorGUILayout.PropertyField(pressedColor);
    
                EditorGUILayout.PropertyField(idleThickness);
                if (changeThickness.boolValue) EditorGUILayout.PropertyField(pressedThickness);
    
                if (EditorApplication.isPlayingOrWillChangePlaymode)
                {
                    EditorGUILayout.PropertyField(_isPressed);
    
                    EditorGUI.BeginDisabledGroup(true);
                    {
                        EditorGUILayout.PropertyField(pointerPosition3D);
                        EditorGUILayout.PropertyField(pointerPosition2D);
                    }
                    EditorGUI.EndDisabledGroup();
                }
    
                serializedObject.ApplyModifiedProperties();
            }
    
            private void DrawScriptField()
            {
                EditorGUI.BeginDisabledGroup(true);
                {
                    EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((LaserPointerController)target), typeof(LaserPointerController), false);
                }
                EditorGUI.EndDisabledGroup();
    
                EditorGUILayout.Space();
            }
        }
    #endif
    
        #endregion Inspector
    
    
        #region Public Members
    
        public Vector3 PointerPosition3D
        {
            get { return pointerPosition3D; }
        }
    
        public Vector2 PointerPosition2D
        {
            get { return pointerPosition2D; }
        }
    
        public bool IsPressed
        {
            get { return isPressed; }
        }
    
        public Transform CurrentlyHoveredTransform
        {
            get { return _currentlyHovered; }
        }
    
        #endregion Public Members
    
    
        #region Private Members
    
        private Transform _holder;
        private Transform _laser;
        private Transform _currentlyHovered;
        private Material _laserMaterial;
    
        private PointerEventData _pointerEventData;
        private Vector2 _lastPointerPosition;
        private bool _isDragging;
        private bool _lastPressed;
        private Camera _camera;
    
        #endregion Private Members
    
    
        #region MonoBehaviour Messages
        private void Awake()
        {
            _holder = new GameObject("LaserHolder").transform;
            _holder.parent = transform;
            _holder.localScale = Vector3.one;
            _holder.localPosition = useOffset ? offset : Vector3.zero;
            _holder.localRotation = Quaternion.identity;
    
            _laser = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            var collider = _laser.GetComponent<Collider>();
    
            if (!useCollider)
            {
                Destroy(_laser.GetComponent<Collider>());
            }
            else
            {
                collider.isTrigger = colliderIsTrigger;
            }
    
            if (useRigidBody)
            {
                var rigidBody = _laser.gameObject.AddComponent<Rigidbody>();
                rigidBody.useGravity = false;
                rigidBody.isKinematic = true;
            }
    
            _laser.name = "LaserPointer";
            _laser.transform.parent = _holder;
            _laser.transform.localScale = new Vector3(idleThickness, idleThickness, maxPointerDistance);
            _laser.transform.localPosition = new Vector3(0f, 0f, maxPointerDistance / 2f);
            _laser.transform.localRotation = Quaternion.identity;
    
            _laserMaterial = new Material(Shader.Find("Unlit/Color")) { color = idleColor };
            _laser.GetComponent<MeshRenderer>().material = _laserMaterial;
    
            _camera = Camera.main;
    
            _pointerEventData = new PointerEventData(EventSystem.current)
            {
                // most Unity comonents e.g. the ScrollRect expect this to be Left
                // otherwise they ignore pointer input
                button = PointerEventData.InputButton.Left
            };
        }
    
        private void OnEnable()
        {
            _holder.gameObject.SetActive(true);
        }
    
        private void OnDisable()
        {
            _holder.gameObject.SetActive(false);
        }
    
        // Update is called once per frame
        private void Update()
        {
            //TODO uncomment this in order to get the isPressed from the according controller
            // curently I only set it via the Inspector
            //isPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
    
            // Initially the dist is the maximum pointer distance
            var dist = maxPointerDistance;
    
            // create the ray from the laserpointer origin
            var ray = new Ray(_holder.position, _holder.forward);
    
            var hit = new RaycastHit();
    
            // If using a Collider we have to ignore the Collider of the LaserPointer itself
            if (useCollider)
            {
                var hits = Physics.RaycastAll(ray, maxPointerDistance);
                hit = hits.FirstOrDefault(h => h.transform != _laser.transform);
            }
            else
            {
                Physics.Raycast(ray, out hit, maxPointerDistance);
            }
    
            // Are we hitting something?
            if (hit.transform)
            {
                // ignore if still pressing the trigger
                if (!isPressed)
                {
                    // Are we hitting something different to what we hit before?
                    if (_currentlyHovered && _currentlyHovered != hit.transform)
                    {
                        ExecuteEvents.ExecuteHierarchy(_currentlyHovered.gameObject, _pointerEventData, ExecuteEvents.pointerExitHandler);
    
                        _currentlyHovered = null;
                    }
    
                    // Are we hitting something new?
                    if (_currentlyHovered != hit.transform)
                    {
                        ExecuteEvents.ExecuteHierarchy(hit.transform.gameObject, _pointerEventData, ExecuteEvents.pointerEnterHandler);
    
                        _currentlyHovered = hit.transform;
                    }
                }
    
                if (_currentlyHovered == hit.transform)
                {
                    // If we are hitting something correct the dist value
                    if (hit.distance < maxPointerDistance)
                    {
                        dist = hit.distance;
                    }
    
                    if (isPressed)
                    {
                        HandlePointerDown(hit.transform);
                    }
                    else
                    {
                        HandlePointerUp(hit.transform);
                    }
                }
            }
            else
            {
                if (!isPressed && _currentlyHovered)
                {
                    HandlePointerUp(_currentlyHovered, true);
    
                    ExecuteEvents.ExecuteHierarchy(_currentlyHovered.gameObject, _pointerEventData, ExecuteEvents.pointerExitHandler);
    
                    _currentlyHovered = null;
                }
            }
    
            // Apply changes in the thickness and set the laser dimensions using the dist
            var thickness = !changeThickness || !isPressed ? idleThickness : pressedThickness;
            _laser.transform.localScale = new Vector3(thickness, thickness, dist);
            _laser.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
    
            // Apply color changes
            if (changeColor) _laserMaterial.color = isPressed ? pressedColor : idleColor;
    
            // Update the pointerEventData
            pointerPosition3D = _laser.transform.position + _laser.transform.forward * dist / 2f;
            pointerPosition2D = _camera.WorldToScreenPoint(pointerPosition3D);
            _pointerEventData.position = pointerPosition2D;
            _pointerEventData.delta = _pointerEventData.position - _lastPointerPosition;
            _lastPointerPosition = _pointerEventData.position;
    
            _lastPressed = isPressed;
        }
    
        #endregion MonoBehaviour Messages
    
    
        #region Private Methods
    
        private void HandlePointerDown(Component target)
        {
            if (!target) return;
    
            // only call once if IsPressed changed its value this frame
            if (_lastPressed != isPressed)
            {
                // Try pointerClickHandler, only use submitHandler as fallback
                // e.g. UI.Button implements both ... would lead to duplicate clicks
                var done = ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.pointerClickHandler);
                if (!done) ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.submitHandler);
    
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.pointerDownHandler);
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.selectHandler);
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.initializePotentialDrag);
            }
            else
            {
                if (!_isDragging)
                {
                    // in the first frame use beginDragHandler
                    ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.beginDragHandler);
                    _isDragging = true;
                    _pointerEventData.dragging = true;
                }
                else
                {
                    // later use dragHandler
                    ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.dragHandler);
                }
            }
        }
    
        private void HandlePointerUp(Component target, bool forceInvoke = false)
        {
            if (!target) return;
    
            // only call once if IsPressed changed its value this frame
            // or forceInvoke is set
            if (_lastPressed != isPressed || forceInvoke)
            {
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.deselectHandler);
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.endDragHandler);
                ExecuteEvents.ExecuteHierarchy(target.gameObject, _pointerEventData, ExecuteEvents.dropHandler);
    
                _isDragging = false;
                _pointerEventData.dragging = false;
            }
        }
    
        #endregion Private Methods
    }
    
