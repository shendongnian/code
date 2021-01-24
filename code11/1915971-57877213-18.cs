    Shader "Custom/GridHighlightShader"
    {
        Properties
        {
            [HideInInspector]_SelectionColor("SelectionColor", Color) = (0.1,0.1,0.1,1)
            [HideInInspector]_MovementColor("MovementColor", Color) = (0,0.205,1,1)
            [HideInInspector]_AttackColor("AttackColor", Color) = (1,0,0,1)
            [HideInInspector]_GlowInterval("_GlowInterval", float) = 1
            _MainTex("Albedo (RGB)", 2D) = "white" {}
            _Glossiness("Smoothness", Range(0,1)) = 0.5
            _Metallic("Metallic", Range(0,1)) = 0.0
            _ColorizeMap("Colorize Map", 2D) = "black" {} 
            _WorldSpaceRange("World Space Range", Vector) = (0,0,100,100)
        }
            SubShader
            {
                Tags { "RenderType" = "Opaque" }
                LOD 200
    
                CGPROGRAM
                // Physically based Standard lighting model, 
                // and enable shadows on all light types
                #pragma surface surf Standard fullforwardshadows
    
                // Use shader model 3.0 target, to get nicer looking lighting
                #pragma target 3.0
    
                struct Input
                {
                    float2 uv_MainTex;
                    float3 worldNormal;
                    float3 worldPos;
                };
    
                sampler2D _MainTex;
                half _Glossiness;
                half _Metallic;
                fixed4 _SelectionColor;
                fixed4 _MovementColor;
                fixed4 _AttackColor;
                half _GlowInterval;
                sampler2D _ColorizeMap;
                fixed4 _WorldSpaceRange;
                
    
                // Add instancing support for this shader. 
                // You need to check 'Enable Instancing' on materials that use the shader.
                // See https://docs.unity3d.com/Manual/GPUInstancing.html 
                // for more information about instancing.
                // #pragma instancing_options assumeuniformscaling
                UNITY_INSTANCING_BUFFER_START(Props)
                    // put more per-instance properties here
                UNITY_INSTANCING_BUFFER_END(Props)
    
                void surf(Input IN, inout SurfaceOutputStandard o)
                {
                    fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
    
                    // Update only the normals facing up and down
                    if (abs(IN.worldNormal.y) >= 0.866)) // abs(y) >= sin(60 degrees)
                    {
                        fixed4 colorizedMapUV = (IN.worldPos.xz-_WorldSpaceRange.xy) 
                                / (_WorldSpaceRange.zw-_WorldSpaceRange.xy);
                        half4 colorType = tex2D(_ColorizeMap, colorizedMapUV);
 
                        if (colorType.x)
                        {
                            c = c + (_SelectionColor * _GlowInterval) - 1;
                        } 
                        else if (colorType.y)
                        {
                            c = c + (_MovementColor * _GlowInterval);
                        }
                        else if (colorType.z)
                        {
                            c = c + (_AttackColor * _GlowInterval);
                        }
                    }
                    o.Albedo = c.rgb;
                    o.Metallic = _Metallic;
                    o.Smoothness = _Glossiness;
                    o.Alpha = c.a;
    
                }
                ENDCG
            }
        FallBack "Diffuse"
    }
