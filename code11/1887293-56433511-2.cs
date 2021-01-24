    Shader "Unlit/cshader4"
    {
        Properties
        {
            _moveCubeT ("MoveCubeT", Float) = 0
            _MainTex ("Texture", 2D) = "white" {}
        }
        CGINCLUDE
            #define time _Time.y 
            float3 Rotx(in float3 p,in float a){
                float c,s; float3 q = p;
                c = cos(a); s = sin(a);
                q.y = c * p.y - s * q.z;
                q.z = s * p.y + c * q.z;
                return q;
            }
    
            float random(float id){
                return frac(sin(id)*678.342231);
            }
        ENDCG
        SubShader
        {
            Tags { "RenderType"="Opaque" }
            LOD 100
    
            Pass{
                CGPROGRAM
                    #pragma target 5.0
                    #pragma vertex vert
                    #pragma fragment frag 
                    #include "UnityCG.cginc"
    
                    sampler2D _MainTex;
    
                    StructuredBuffer<float3> vertexbuffer;
                    StructuredBuffer<float3> posbuffer;
                    float _moveCubeT;
                    struct vertIN{
                        uint vID : SV_VertexID;
                        uint ins : SV_InstanceID;
                    };
    
                    struct vertOUT{
                        float4 pos : SV_POSITION;
                    };
    
                    vertOUT vert(vertIN i){
                        vertOUT o = (vertOUT)0;
                            float3 startingpos = float3(0,0,0); //set starting pos for each cube here
                            float4 position = float4(vertexbuffer[i.vID],1);
                            position.xyz = Rotx(position.xyz,time*(1+random(i.ins)));
                            position.xyz += lerp(startingpos, posbuffer[i.ins], _moveCubeT);
                            o.pos = UnityObjectToClipPos(position);
                        return o;
                    }
    
                    fixed4 frag(vertOUT ou):SV_Target{
    
                        return 1;
                    }
                ENDCG
            }
        }
    }
